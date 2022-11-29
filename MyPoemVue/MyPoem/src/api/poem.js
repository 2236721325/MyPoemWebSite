import  request  from './request';


const countPoem=()=>
{
    return request.post({
        url:'/api/app/china-poem/count'
    });
}
const GetPoemPagedList=(data)=>
{
    return request.get({
        url: 'api/app/china-poem/paged-list',
        data:data
    });
}
const GetPoem=(data)=>
{
    return request.get({
        url: `api/app/china-poem/${data.id}`,
    });
}
const searchPoem=(params)=>
{
    return request.post({
        url:'api/app/china-poem/search-paged-list',
        params:params
    })
}

export default{
    countPoem,
    GetPoemPagedList,
    GetPoem,
    searchPoem
}