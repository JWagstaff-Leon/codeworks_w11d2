<template>
    <h2 class="no-select selectable" @click="makeActive">{{company.name}}</h2>
</template>

<script>
import { AppState } from '../AppState.js';
import { jobsService } from '../services/JobsService.js';
export default
{
    props:
    {
        company:
        {
            type: Object,
            required: true
        }
    },

    setup(props)
    {
        return {
            async makeActive()
            {
                await jobsService.getCompanyJobs(props.company.id);
                AppState.selectedContractor = props.company;
                AppState.contractorSelected = false;
            }
        }
    }
}
</script>

<style lang="scss" scoped>

</style>