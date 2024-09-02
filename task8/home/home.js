

var quantity = document.getElementById("quantity")
function  CartId(){


    localStorage.setItem("userid",1)
    localStorage.setItem("cartid",1)
   
}
async function Add(){
    debugger;
    const url ="https://localhost:44358/api/CartItem";
var data ={
    cartId:localStorage.getItem("cartid"),
    productId: localStorage.getItem("productId"),
    quantity: quantity.value
  }
    var resquest= await fetch(url,
    {

       method:"POST",
       body:JSON.stringify(data),
       headers:{
        'Content-Type':'application/json'
       }

    
    });

}