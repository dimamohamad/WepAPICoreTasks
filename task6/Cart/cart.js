var n = localStorage.getItem("cartid");
var productId = localStorage.getItem("productid")
var url = `https://localhost:44358/GetDataById/${n}`;

var tbody = document.getElementById("tbody");

async function allcart() {
    var resquest = await fetch(url);
    var response = await resquest.json();
    response.forEach(element => {
        var row = document.createElement("tr");
        row.innerHTML += `
        
        <td>${element.product.productName}</td>
        <td>${element.product.price}</td>
        <td ><input id="quantity${element.cartItemId}" type="number" value="${element.quantity}"/></td>
        <td>${element.product.description}</td>
         <td><button class="btn btn-outline-danger" onclick="deleteProduct(${element.cartItemId})">Remove</button><button class="btn btn-outline-primary" onclick="Update(${element.cartItemId})">Update</button></td>
        
        `;
        tbody.appendChild(row);




    });
}

async function deleteProduct(id) {
    var url = `https://localhost:44358/api/CartItem/${id}`
        ;

    let request = await fetch(url, {
        method: "DELETE",
    });
    alert("the item deleted successfully");
    window.location.reload();
}





async function Update(id) {
    debugger
    var url = `https://localhost:44358/api/CartItem/${id}`;
    var input = document.getElementById(`quantity${id}`).value;
    debugger
    event.preventDefault();
    let response = await fetch(url, {

        method: "PUT",
        body: JSON.stringify(
            {
                Quantity: input,

            }),
        headers: {
            'Content-Type': 'application/json'
        }


    });
    const update = await response.json();
    document.getElementById("quantity").textContent = update.quantity;
    alert("llllll");




}
allcart();