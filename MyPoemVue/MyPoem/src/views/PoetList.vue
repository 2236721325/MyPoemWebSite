<script setup>
  import { Search } from '@element-plus/icons-vue'
  import { reactive, ref } from "vue";
  import { onMounted } from "vue";
  import api from "../api/poet";
  import { useRoute, useRouter } from 'vue-router'
  import global from '../global/global';

  
  const input = ref('');
  let pageSize = 5
  let totalCount = ref(0);
  let totalPage = ref(0);
  let currentIndex = ref(global.poetIndex);
  const router=useRouter()
  
  
  const currentPage = reactive(
      {
          poetList: [{
              name: '',
              id: '',
              discriptions:''
          }
          ]
      }
  );
  onMounted(() => {

      InitData();
  })
  
  const InitData = async () => {
    if(global.poetSerach)
    {
      api.searchPoet({
            poetName:global.poetSearchInput,
            skipCount: (global.poetIndex-1)*pageSize,
            maxResultCount: pageSize
        }).then(res => {
            currentPage.poetList = res.data.result.items;
            totalCount.value=res.data.result.totalCount
        });

    }
    else
    {
      api.countPoet().then(res => {
          totalCount.value = res.data.result;
          console.log(res.data.result);
          totalPage.value = Math.ceil(currentPage.totalCount / pageSize);
          api.GetPoetPagedList({
              skipCount: (currentIndex.value-1)*pageSize,
              maxResultCount: pageSize
          }).then(res => {
              currentPage.poetList = res.data.result.items;
          })
      })
    }
      
  }
  const handleCurrentChange=(page)=>
  {
      currentIndex.value=page;
      global.poetIndex=page;
      if(global.poetSerach)
      {
        api.searchPoet({
            poetName:global.poetSearchInput,
            skipCount: (global.poetIndex-1)*pageSize,
            maxResultCount: pageSize
        }).then(res => {
            currentPage.poetList = res.data.result.items;
        });
      }
      else 
      {
        api.GetPoetPagedList({
              skipCount: (currentIndex.value-1)*pageSize,
              maxResultCount: pageSize
          }).then(res => {
              currentPage.poetList = res.data.result.items;
          })
      }
    
  
  }
  const toDetailPoem=(id)=>
  {
      router.push({
      path:`/DetailPoet/${id}`
    });
  }
  const SearchHandle=()=>{
    global.poetIndex=1;
    currentIndex.value=1;
    global.poetSerach=true;
    global.poetSearchInput=input.value;
    api.searchPoet({
            poetName:global.poetSearchInput,
            skipCount: (global.poetIndex-1)*pageSize,
            maxResultCount: pageSize
        }).then(res => {
            currentPage.poetList = res.data.result.items;
            totalCount.value=res.data.result.totalCount;
        });

  }
  </script>
      
  <template>
      <div class="all">
          <div class="search">
              <el-input v-model="input" placeholder="输入诗人名称" class="input-with-select" size="large">
                  <template #append>
                      <el-button :icon="Search" @click="SearchHandle" />
                  </template>
              </el-input>
          </div>
          <div class="main">
              <div v-for="poet in currentPage.poetList" :key="poet.id" class="card">
                  <el-card class="box-card">
                      <template #header>
                          <div class="card-header">
                              <span><h1>{{poet.name}}</h1></span>
                              <el-button class="button" @click="toDetailPoem(poet.id)" text><h1>详细内容</h1></el-button>
                          </div>
                      </template>
                      <p>描述:{{poet.discriptions}}</p>
                  </el-card>
              </div>
          </div>
          <el-pagination background layout="prev, pager, next" :total="totalCount"
          @current-change="handleCurrentChange"
          :current-page="currentIndex"
          :pageSize="pageSize"
          
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