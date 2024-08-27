



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
        <button class="btn btn-primary" onclick="clic11k(${result.productId})">Details </button>

    </div>
    </div>
    ;`






}

function clic11k(id){
    localStorage.setItem("productid",id);
    window.location.href="../products/details.html"
  }

GetProducts();