

const n = localStorage.getItem("categoryid");
debugger;
var url;
if (n) {
    url =`https://localhost:44358/api/Products/Products/productsbycategoryid/${n}`;
}
else {
    url='https://localhost:44358/api/Products';
}
async function GetProducts() {


    var response = await fetch(url);

    var result = await response.json();

    var container = document.getElementById('tbody');

    result.forEach((category) => {
        container.innerHTML +=
            `    
    <tr>
      <th scope="row">*-*</th>
      <td><img src="${category.productImage}" " (image not found)" style="width: 50px; height: auto;"></td>
      <td>${category.productName}</td>
       <td>${category.productId}</td>
      <td>${category.price}</td>
      <td>
      
       
        <a href="../Products/updateproduct.html"  onclick="clic12k(${category.productId})">Edit</a>
      </td>
    </tr>
    <!-- End example row -->
    `;
    });





}

function clic11k(id) {
    localStorage.setItem("productid", id);
    window.location.href = "../products/details.html"
}

function clic12k(id) {
    localStorage.setItem("productid", id);
    window.location.href = "../editProduct/edit.html"
}

function myfun1(){
    window.location.href="../Products/addproduct.html"
  }
GetProducts();