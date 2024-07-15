<script setup lang="ts">
    import {defineProps, onMounted, ref, watch } from 'vue';

    interface Props {
        loading: string,
        url: string
    }

    interface Result {
        searchTerms: null | string,
        searchUrl: null | string
        positions: null | string
    }

    interface Data {
        isFetching: boolean,
        responseData: null | { positions : string}
        searchTerms: null | string,
        searchUrl: null | string
        results: Result []
    }

    const props = defineProps<Props>();
    let data = ref<Data>();
    data.value = {
        isFetching: false, responseData: null, searchTerms: null, searchUrl: null, results: []};

    async function fetchData(): Promise<void> {
        try {
            const response = await fetch(props.url + data.value!.searchTerms!.replace(/\s+/g, '+') + '/' + data.value?.searchUrl);
            const res = await response.json();

            if (res.success === "True") {
                data.value!.responseData! = res;
                data.value!.results?.push({
                    searchTerms: data!.value!.searchTerms,
                    searchUrl: data!.value!.searchUrl,
                    positions: data!.value!.responseData!.positions,
                });
            } else {
                alert(res.error);
            }
        } catch (error) {
            console.error("Error fetching data:", error);
        } finally {
            data.value!.isFetching = false;
        }
    }

</script>

<template>
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <h5>Search Google Ranking</h5>
                <div class="mb-3">
                    <input v-model="data.searchTerms" type="text" class="form-control" placeholder="Enter search terms" />
                </div>
                <div class="mb-3">
                    <input v-model="data.searchUrl" type="text" class="form-control" placeholder="Enter search URL" />
                </div>
                <button @click="fetchData" class="btn btn-primary">Search</button>
            </div>
            <div class="col-md-6">
                <h5>Search Results:</h5> 
                    <table class="table">
                        <thead>
                            <tr>
                                <th scope="col">Search Phrase</th>
                                <th scope="col">URL</th>
                                <th scope="col">Result</th>
                            </tr>
                        </thead>
                        <tbody v-if="data.responseData">
                            <tr v-for="item in data.results">
                                <td>{{item.searchTerms}}</td>
                                <td>{{item.searchUrl}}</td>
                                <td>{{item.positions}}</td>
                            </tr>
                        </tbody>
                </table>
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
