const url ='https://localhost:44358/api/Categories';

async function GetCategories() {


    var response  = await fetch(url);

    var result = await response.json();

    var container = document.getElementById('container');


    result.forEach((category) => {
        container.innerHTML += 
        `    <div class="card" style="width: 18rem;">
        <img class="card-img-top" src="${category.categoryImage}" alt="${category.categoryImage} (image not found)">
        <div class="card-body">
            <h5 class="card-title">${category.categoryName}</h5>
            <p class="card-text">${category.categoryId}</p>
         
            <button class="btn btn-primary" onclick="myFunction(${category.categoryId})">Click me</button>
             <button class="btn btn-primary" onclick="myFunction11(${category.categoryId})">Edit</button>
        </div>
        </div>
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
        window.location.href="../editCategory/edit.html"
      }
GetCategories();




// var div  = document.createElement('div');
//     div.classList.add('card');

  
//     var div2  = document.createElement('div');
//      div2.classList.add('card-body');

//      div.appendChild(div2);
    

//      var img=document.createElement('img')
//      img.classList.add('card-img-top');
//      img.src=element.categoryImage;
//     div2.appendChild(img);


//      var h5  = document.createElement('h5');
//      h5.classList.add('card-title');
//      h5.textContent = element.categoryName;

//      div2.appendChild(h5);

//       var P =document.createElement('p');
//     P.classList.add('card-text');
//     P.textContent = element.categoryId;
//     div2.appendChild(P);

//      container.appendChild(div);