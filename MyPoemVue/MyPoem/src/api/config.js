import axios from "axios";

const Service=axios.create({
    baseURL:'http://43.142.56.188:8123',
    //定义同意请求头
    headers:{
        "Content-Type":"application/json; charset=utf-8"
    }
})
export default Service