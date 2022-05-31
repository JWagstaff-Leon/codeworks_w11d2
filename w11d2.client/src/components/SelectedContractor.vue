<template>
    <div class="d-flex flex-column details position-relative">
        <div class="d-flex flex-grow-1">
            <div class="d-flex flex-column">
                <h4>Contractor</h4>
                <h5>{{contractor.name}}</h5>
            </div>
            <div class="d-flex flex-column ms-5">
                <h4>Jobs</h4>
                <div class="d-flex">
                    <h5 v-for="c in companies" :key="c.id">{{c.name}}</h5>
                </div>
            </div>
        </div>
        <div class="fab bg-primary action" title="new job">
            
        </div>
    </div>
</template>

<script>
import { computed } from '@vue/reactivity'
import { AppState } from '../AppState.js'
export default
{
    setup()
    {
        return {
            contractor: computed(() => AppState.selectedContractor),
            companies: computed(() => AppState.selectedCompanies)
        }
    }
}
</script>

<style lang="scss" scoped>
.details
{
    height: 15vh;
    border-top: 2px solid black;
    max-width: 100vw;
    overflow-x: scroll;
}
.fab
{
    position: absolute;
    bottom: 5px;
    left: 5px;
    border-radius: 50%;
    height: 6vh;
    width: 6vh;
    border: 1.5px solid black;
}
</style>