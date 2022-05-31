<template>
    <main class="d-flex flex-column">
        <div class="d-flex flex-grow-1" :style="{maxHeight: (!contractorSelected && !companySelected ? '100vh' : '85vh')}">
            <Contractors />
            <Companies />
        </div>
    <SelectedContractor v-if="contractorSelected"/>
    <SelectedCompany v-if="companySelected" />
  </main>
</template>

<script>
import {  computed, onMounted } from 'vue'
import { contractorsService } from "./services/ContractorsService.js";
import { companiesService } from "./services/CompaniesService.js";
import Loader from './utils/Loader.js';
import { AppState } from './AppState.js';
export default {
    name: 'App',
    setup()
    {
        onMounted(async () => 
        {
            const loader = new Loader();
            loader.step(contractorsService.getAll);
            loader.step(companiesService.getAll);
            await loader.load();
        });
        return {
            contractorSelected: computed(() => AppState.contractorSelected == true),
            companySelected: computed(() => AppState.contractorSelected == false)
        }
    }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";
</style>
