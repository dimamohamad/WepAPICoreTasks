



const n = localStorage.getItem("categoryid");
var url;
if (n){
 url =`https://localhost:44358/api/Products/Products/productsbycategoryid/${n}`;
}
else {
    url='https://localhost:44358/api/Products';
}
async function GetProducts() {


    var response  = await fetch(url);

    var result = await response.json();

    var container = document.getElementById('container');

result.forEach((category) => {
    container.innerHTML += 
    `    <div class="card" style="width: 18rem;">
    <img class="card-img-top" src="${category.productImage}" alt="${category.productImage} (image not found)">
    <div class="card-body">
        <h5 class="card-title">${category.productName}</h5>
        <p class="card-text">${category.price}</p>
        <button class="btn btn-primary" onclick="clic11k(${category.productId})">Details </button>

    </div>
    </div>
    ;`
});





}

function clic11k(id){
    localStorage.setItem("productid",id);
    window.location.href="../products/details.html"
  }

GetProducts();