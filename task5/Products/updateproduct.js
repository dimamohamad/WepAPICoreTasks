

async function getCategoryName() {
    const dropDown = document.getElementById("dropDownList");
    let url = "https://localhost:44358/api/Categories";
    let request = await fetch(url);
    let data = await request.json();
  
    data.forEach((select) => {
      dropDown.innerHTML += `
      <option value="${select.categoryId}">${select.categoryName}</option>
    `;
    });
  }
  
  getCategoryName();
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
     window.location.href = "../Products/showproduct.html"
   alert("your product has successfully edited");
}