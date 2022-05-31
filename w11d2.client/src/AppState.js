import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
    user: {},
    account: {},

    contractors: null,
    companies: null,

    contractorSelected: null,

    selectedContractor: null,
    selectedContractors: null,

    selectedCompany: null,
    selectedCompanies: null,
});
