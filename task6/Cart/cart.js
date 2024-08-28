var n= localStorage.getItem("cartid");
const url =`https://localhost:44358/GetDataById/${n}`;

var tbody =document.getElementById("tbody");

async function allcart() {
    var resquest=await fetch(url) ;
    var response= await resquest.json();
    response.forEach(element => {
        var  row = document.createElement("tr");
        row.innerHTML +=`
        
        <td>${element.product.productName}</td>
        <td>${element.product.price}</td>
        <td>${element.quantity}</td>
        <td>${element.product.description}</td>
       
        `;
        tbody.appendChild(row);
        
        
        

    });
}
allcart();