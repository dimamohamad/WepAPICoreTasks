


const n = localStorage.getItem("productid");
var url = `https://localhost:44358/api/Products/${n}`;
var form = document.getElementById("form");
async function fun() {
   
    var formData = new FormData(form);
    event.preventDefault();
    let response = await fetch(url, {
        method: 'PUT',
        body: formData,
    });
    var data = response;
   alert("your product has successfully edited");
}