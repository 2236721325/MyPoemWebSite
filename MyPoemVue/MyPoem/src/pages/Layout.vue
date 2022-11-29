<script setup>
import { RouterLink, RouterView } from 'vue-router'
import { ref } from 'vue'
</script>
    
<template>
    <el-container class="all">
        <el-header class="hd">
            <h3>我的诗歌网站</h3>
            <div class="router">
                <RouterLink to="/">诗歌</RouterLink>
                <RouterLink to="/PoetList">诗人</RouterLink>
            </div>
        </el-header>
        <el-main class="mainView">
            <RouterView></RouterView>
        </el-main>
    </el-container>






</template>
    
<style scoped>
.hd {
    background-color: #FFFFFF;
    display: flex;
    align-items: center;
}

.search {
    width: 72%;
    margin-left: 3%;
    background-color: var(--el-fill-color-blank);

}

.router {
    display: flex;
    flex-grow: 1;
    justify-content: flex-end;
    gap: 3%
}

.mainView {
    margin-left: auto;
    margin-right: auto;
    /* background-color: #FFFFFF; */
    height: auto;
    margin-top: 1%;
    display: flex;
    flex-direction: column;
    justify-content: center;
}

.all {
    display: flex;
    width: 100%;
    height: 100%;
}
</style>