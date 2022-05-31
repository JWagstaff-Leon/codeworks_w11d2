<template>
    <div class="flex-grow-1 d-flex flex-column p-3">
        <button class="btn btn-primary p-3 mb-2" @click="showModal">Add Contractor</button>
        <div class="scrollable">
            <Contractor v-for="con in contractors" :key="con.id" :contractor="con" />
        </div>
    </div>
    <Modal id="add-contractor-modal">
        <template #modal-title>
            <h4>Add Contractor</h4>
        </template>
        <template #modal-body>
            <form @submit.prevent="addContractor" class="d-flex flex-column">
                <div>
                    <label>Contractor Name: </label>
                    <input v-model="contractorName" class="ms-3" />
                </div>
                <button class="btn btn-primary mt-3">Submit</button>
            </form>
        </template>
    </Modal>
</template>

<script>
import { computed, ref } from '@vue/reactivity'
import { AppState } from '../AppState.js'
import Pop from '../utils/Pop.js';
import { logger } from '../utils/Logger.js';
import { Modal } from 'bootstrap';
import { contractorsService } from "../services/ContractorsService.js";
export default
{
    setup()
    {
        const contractorName = ref("");
        return {
            contractorName,
            contractors: computed(() => AppState.contractors),
            showModal()
            {
                Modal.getOrCreateInstance(document.getElementById("add-contractor-modal")).show();
            },
            async addContractor()
            {
                try
                {
                    await contractorsService.create({name: contractorName.value});
                    Modal.getOrCreateInstance(document.getElementById("add-contractor-modal")).hide();
                    Pop.toast("Contractor added", "success");
                    contractorName.value = "";
                }
                catch(error)
                {
                    logger.error("[Contractors.vue > addContractor]", error.message);
                    Pop.toast(error.message, "error");
                }
            }
        }
    }
}
</script>

<style lang="scss" scoped>
.scrollable
{
    max-height: 100%;
    overflow-y: scroll;
}
</style>