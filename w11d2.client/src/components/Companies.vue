<template>
    <div class="flex-grow-1 d-flex flex-column p-3">
        <button class="btn btn-danger p-3 mb-2" @click="showModal">Add Company</button>
        <div class="scrollable">
            <Company v-for="com in companies" :key="com.id" :company="com" />
        </div>
    </div>
    <Modal id="add-company-modal">
        <template #modal-title>
            <h4>Add Company</h4>
        </template>
        <template #modal-body>
            <form @submit.prevent="addCompany" class="d-flex flex-column">
                <div>
                    <label>Company Name: </label>
                    <input v-model="companyName" class="ms-3" />
                </div>
                <button class="btn btn-danger mt-3">Submit</button>
            </form>
        </template>
    </Modal>
</template>

<script>
import { computed, ref } from '@vue/reactivity'
import { AppState } from '../AppState.js'
import { Modal } from 'bootstrap'
import { logger } from '../utils/Logger.js'
import Pop from '../utils/Pop.js'
import { companiesService } from '../services/CompaniesService.js'
export default
{
    setup()
    {
        const companyName = ref("");
        return {
            companyName,
            companies: computed(() => AppState.companies),
            showModal()
            {
                Modal.getOrCreateInstance(document.getElementById("add-company-modal")).show();
            },
            async addCompany()
            {
                try
                {
                    await companiesService.create({name: companyName.value});
                    Modal.getOrCreateInstance(document.getElementById("add-company-modal")).hide();
                    Pop.toast("Company added", "success");
                    contractorName.value = "";
                }
                catch(error)
                {
                    logger.error("[Companies.vue > addCompany]", error.message);
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