<script setup>
import { Search } from '@element-plus/icons-vue'
import { reactive, ref } from "vue";
import { onMounted } from "vue";
import { useRouter } from "vue-router";

import api from "../api/poet";
const router = useRouter();

const poet = ref({
    id: '',
    name: '',
    discriptions: ''
})
const poems = ref([{
    id: '',
    title: '',
    chinaAuthorName: ''
}

]
)
onMounted(() => {
    InitData();
})
const InitData = async () => {
    var id = router.currentRoute.value.params.id;
    api.GetPoet({
        id: id
    }).then(res => {
        poet.value = res.data.result;
    })
    api.countPoemById(id)
        .then(res1 => {
            api.GetPoemPagedListById({
                id: id,
                skipCount: 0,
                maxResultCount: res1.data.result
            }).then(res2 => {
                poems.value = res2.data.result.items;
                for (let index = 0; index < res2.data.result.items.length; index++) {
                   
                    console.log(res2.data.result.items[index].title)

                }
            })
        });
}

</script>
        
<template>
    <div class="all">
        <div class="main">
            <h1>{{poet.name}}</h1>
            <h2>描述</h2>
            <p class="text">{{poet.discriptions}}</p>
            <h2>作者诗作：</h2>
            <div v-for="p in poems" :key="p.id">
                <RouterLink :to="{path:`/DetailPoem/${p.id}`}">{{p.title}}</RouterLink>
            </div>
        </div>
    </div>




</template>
    
<style scoped>
.all {
    display: flex;
    flex-direction: column;
    align-items: center;
    height: 100%;
}

.text {
    font-size: 20px;
}

.main {
    margin: 3%;
    background-color: #FFFFFF;
    height: 100%;
    width: 100vh;
    display: flex;
    flex-direction: column;
    align-items: center;
}
</style>