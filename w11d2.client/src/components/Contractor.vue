<template>
    <h2 class="no-select selectable" @click="makeActive">{{contractor.name}}</h2>
</template>

<script>
import { AppState } from '../AppState.js'
import { jobsService } from "../services/JobsService.js";
export default
{
    props:
    {
        contractor:
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
                await jobsService.getContractorJobs(props.contractor.id);
                AppState.selectedContractor = props.contractor;
                AppState.contractorSelected = true;
            }
        }
    }
}
</script>

<style lang="scss" scoped>

</style>