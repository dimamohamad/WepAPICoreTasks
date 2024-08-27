var url="https://localhost:44358/api/Products";
var form=document.getElementById("form");
async function fun() {

    event.preventDefault();
    var formData=new FormData(form);
    let respons =await fetch (url,{
        method: 'POST',
        body: formData,


    });
    var data=respons;
     window.location.href = "../Products/products.html"
    
}