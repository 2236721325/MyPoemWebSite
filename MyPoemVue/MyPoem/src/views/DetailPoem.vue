<script setup>
import { Search } from '@element-plus/icons-vue'
import { reactive, ref } from "vue";
import { onMounted } from "vue";
import { useRouter } from "vue-router";

import api from "../api/poem";
const router = useRouter();
const poem = ref({
    id: '',
    title: '',
    chinaAuthorName: '',
    paragraphs: []
})

onMounted(() => {
    InitData();
})

const InitData = async () => {
    var id = router.currentRoute.value.params.id;
    api.GetPoem({
        id: id
    }).then(res => {
        console.log(res.data);
        poem.value = res.data.result;
    })
}

</script>
        
<template>


    <div class="all">
        <div class="main">
            <h1>{{poem.title}}</h1>
            <h3>作者：{{poem.chinaAuthorName}}</h3>
            <div v-for="p in poem.paragraphs" :key="p">
                <p class="text">{{p}}</p>
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
.text{
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