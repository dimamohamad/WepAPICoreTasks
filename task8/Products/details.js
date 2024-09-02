

function  CartId(){


    localStorage.setItem("userid",1)
    localStorage.setItem("cartid",1)
   
}



const n = localStorage.getItem("productid");
var url=`https://localhost:44358/api/Products/${n}`;

async function GetProducts() {


    var response  = await fetch(url);

    var result = await response.json();

    var container = document.getElementById('container');


    container.innerHTML = 
    `    <div class="card" style="width: 18rem;">
    <img class="card-img-top" src="${result.productImage}" alt="${result.productImage} (image not found)">
    <div class="card-body">
        <h5 class="card-title">${result.productName}</h5>
        <p class="card-text">${result.price}</p>
        <input type="number" id="quantity" />
       
        <button class="btn btn-primary" onclick="Add()">add to Cart </button>

    </div>
    </div>
    ;`









    



}



async function Add(){

    // debugger;
    var quantity=document.getElementById("quantity")
    const url ="https://localhost:44358/api/CartItem";
var data ={
    cartId:localStorage.getItem("cartid"),
    productId: localStorage.getItem("productid"),
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
    alert ("the item added to the cart successfully")
window.location.href="../Cart/cart.html"
}

function clic11k(id){
    localStorage.setItem("productid",id);
    
    window.location.href="../Cart/addCart.html"
  }

GetProducts();
CartId();
 // <button class="btn btn-primary" onclick="clic11k(${result.productId})">Add to Cart </button>