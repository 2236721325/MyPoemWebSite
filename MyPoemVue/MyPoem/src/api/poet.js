import  request  from './request';


const countPoet=()=>
{
    return request.post({
        url:'/api/app/china-author/count'
    });
}
const GetPoetPagedList=(data)=>
{
    return request.get({
        url: 'api/app/china-author/paged-list',
        data:data
    });
}
const countPoemById=(id)=>
{
    return request.post({
        url:`api/app/china-poem/count/${id}`
    });
}
const GetPoet=(data)=>
{
    return request.get({
        url: `api/app/china-author/${data.id}`,
    });
}
const GetPoemPagedListById=(data)=>
{
    return request.get({
        url: `api/app/china-poem/paged-list/${data.id}?skipCount=${data.skipCount}&maxResultCount=${data.maxResultCount}`
    });
}
const searchPoet=(params)=>
{
    return request.post({
        url:'api/app/china-author/search-paged-list',
        params:params
    })
}
// const GetPoet=(data)=>
// {
//     return request.get({
//         url: 'api/app/china-poem/china-poem',
//         data:data
//     });
// }

export default{
    countPoet,
    GetPoetPagedList,
    GetPoet,
    searchPoet,
    countPoemById,
    GetPoemPagedListById
}