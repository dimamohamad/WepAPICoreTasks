const url ='https://localhost:44358/api/Categories';

async function GetCategories() {


    var response  = await fetch(url);

    var result = await response.json();

    var container = document.getElementById('tbody');


    result.forEach((category) => {
        container.innerHTML += 
        `   

   
    <tr>
      <th scope="row">*-*</th>
      <td><img src="${category.categoryImage}" "(image not found)" style="width: 50px; height: auto;"></td>
      <td>${category.categoryName}</td>
      <td>${category.categoryId}</td>
      <td>
      
       
        <a href="../Category/updatecategory.html" class="btn btn-outline-primary" onclick="myFunction11(${category.categoryId})">Edit</a>
        <button class="btn btn-outline-danger" onclick="deleteProduct(${category.categoryId})">Delete</button>
      </td>
    </tr>
    <!-- End example row -->
 


        `
    });
  

console.log(result)
}

// function clic11k(id){
// debugger
//     localStorage.categoryId=id;
    
//       };


      function myFunction(id){
        localStorage.setItem("categoryid",id);
        window.location.href="../products/products.html"
      }
      function myFunction11(id){
        localStorage.setItem("categoryid",id);
        window.location.href="../Admin/Admin.html"
      }

     function myfun1(){
        window.location.href="../Category/addcategory.html"
      }


      async function deleteProduct(categoryId) {
        var url = `https://localhost:44358/api/Categories/${categoryId}`;
      
        let request = await fetch(url, {
          method: "DELETE",
        });
          alert("Product Deleted");
          window.location.href = "Admin.html";
      }
GetCategories();

