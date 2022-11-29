import Service from "./config";
//Get
const get=(config)=>{
    return Service({
        ...config,
        method:'get',
        params:config.data
    });
}
//Post
const post=(config)=>
{
    return Service({
        ...config,
        method:'post',
        params:config.params,
        data:config.data
    })
}
const put=(config)=>
{
    return Service({
        ...config,
        method:'put',
        data:config.data
    })
}

export default{
    get,
    post
}