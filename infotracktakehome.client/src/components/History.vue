<script setup lang="ts">
    import {defineProps, onMounted, ref, watch } from 'vue';

    interface Props {
        loading: string,
        url: string
    }

    interface Data {
        isFetching: boolean,
        responseData: null |{
            history: History[]
        }
    }

    interface History {
        id : number,
        searchPhrase : string,
        url : string,
        result : string,
        searchDate : Date
    }

    const props = defineProps<Props>();
    let data = ref<Data>();
    data.value = { isFetching: false, responseData: null };

//  watch(() => data.value!.responseData, () => {})

    onMounted(async () => {
        await fetchData();
    })

    async function fetchData(): Promise<void> {
        fetch(props.url)
            .then(r => r.json())
            .then(json => {
                data.value!.responseData = json;
                data.value!.isFetching = false;
                return;
            });
    }

</script>

<template>
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div v-if="data.responseData">
                    <h5>Search Results:</h5>
                    <table class="table">
                        <thead>
                            <tr>
                                <th scope="col">#</th>
                                <th scope="col">Search Phrase</th>
                                <th scope="col">URL</th>
                                <th scope="col">Result</th>
                                <th scope="col">Search Date</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="(item,index) in data.responseData!.history">
                                <th scope="row">{{index}}</th>
                                <td>{{item.searchPhrase}}</td>
                                <td>{{item.url}}</td>
                                <td>{{item.result}}</td>
                                <td>{{item.searchDate}}</td>             
                            </tr>
                        </tbody> 
                    </table>
                </div>
            </div>
        </div>
    </div>
</template>

<style scoped>
    .container {
        padding: 20px;
    }

    .mb-3 {
        margin-bottom: 1rem;
    }

    .mt-3 {
        margin-top: 1rem;
    }

    .list-group-item {
        font-size: 16px;
    }
</style>
