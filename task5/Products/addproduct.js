
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
     window.location.href = "../Products/showproduct.html"
     alert("your product have been added successfully")
    
}