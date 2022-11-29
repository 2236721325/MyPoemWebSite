<script setup>
import { Search } from '@element-plus/icons-vue'
import { reactive, ref } from "vue";
import { onMounted } from "vue";
import api from "../api/poem";
import { useRoute, useRouter } from 'vue-router'
import global from '../global/global';

const input = ref('');
let pageSize = 5
let totalCount = ref(0);
let totalPage = ref(0);
let currentIndex = ref(global.poemIndex);
const router=useRouter()


const currentPage = reactive(
    {
        poemList: [{
            title: '',
            id: '',
            chinaAuthorName: ''
        }
        ]
    }
);
onMounted(() => {
    InitData();
})

const InitData = async () => {
    if(global.poemSerach)
    {
        api.searchPoem({
            poemName:global.poemSearchInput,
            skipCount: (global.poemIndex-1)*pageSize,
            maxResultCount: pageSize
        }).then(res => {
            currentPage.poemList = res.data.result.items;
            totalCount.value=res.data.result.totalCount
        });
    }
    else 
    {
        api.countPoem().then(res => {
        totalCount.value = res.data.result;
        totalPage.value = Math.ceil(currentPage.totalCount / pageSize);
        api.GetPoemPagedList({
            skipCount: (currentIndex.value-1)*pageSize,
            maxResultCount: pageSize
        }).then(res => {
            currentPage.poemList = res.data.result.items;
            totalCount.value=res.data.result.totalCount
        })

    })
    }
   
}
const handleCurrentChange=(page)=>
{
    currentIndex.value=page;
    global.poemIndex=page;
    if(global.poemSerach)
    {
        api.searchPoem({
            poemName:global.poemSearchInput,
            skipCount: (page-1)*pageSize,
            maxResultCount: pageSize
        }).then(res => {
            currentPage.poemList = res.data.result.items;
            totalCount.value=res.data.result.totalCount
        });
    }
    else
    {
        api.GetPoemPagedList({
            skipCount: (currentIndex.value-1)*pageSize,
            maxResultCount: pageSize
        }).then(res => {
            currentPage.poemList = res.data.result.items;
        })
    }
    

}
const toDetailPoem=(id)=>
{
    router.push({
    path:`/DetailPoem/${id}`
  });
}
const searchPoem=()=>
{
    global.poemIndex=1;
    currentIndex.value=1;
    global.poemSerach=true;
    global.poemSearchInput=input.value;
    api.searchPoem({
            poemName:input.value,
            skipCount: 0,
            maxResultCount: pageSize
        }).then(res => {
            currentPage.poemList = res.data.result.items;
            totalCount.value=res.data.result.totalCount
        })
}
</script>
    
<template>
    <div class="all">
        <div class="search">
            <el-input v-model="input" placeholder="输入诗歌名称" class="input-with-select" size="large">
                <template #append>
                    <el-button :icon="Search" @click="searchPoem" />
                </template>
            </el-input>
        </div>
        <div class="main">
            <div v-for="poem in currentPage.poemList" :key="poem.id" class="card">
                <el-card class="box-card">
                    <template #header>
                        <div class="card-header">
                            <span><h1>{{poem.title}}</h1></span>
                            <el-button class="button" @click="toDetailPoem(poem.id)" text><h1>详细内容</h1></el-button>
                        </div>
                    </template>
                    <h1>作者:{{poem.chinaAuthorName}}</h1>
                </el-card>
            </div>
        </div>
        <el-pagination background layout="prev, pager, next" :total="totalCount"
        @current-change="handleCurrentChange"
        :current-page="currentIndex"
        :page-size="pageSize"
        />
    </div>





</template>

<style scoped>
.search {
    width: 100vh;

}

.all {
    display: flex;
    flex-direction: column;
    align-items: center;
}

.card {
    margin: 3%;
}
.card-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.text {
  font-size: 14px;
}

.item {
  margin-bottom: 18px;
}

.box-card {
  width: 480px;
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