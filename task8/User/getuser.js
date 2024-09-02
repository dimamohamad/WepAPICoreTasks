
async function apperdata(){
   event.preventDefault();
    debugger;
    var id =document.getElementById("userId");
const url =`https://localhost:44358/api/Users/${id.value}`

    var form=document.getElementById("userForm");

    
    var response  = await fetch(url);

    var result = await response.json();


    var userid=document.getElementById("Id");
    var username=document.getElementById("name");
    var email=document.getElementById("email1");
userid.value=result.userId;
username.value=result.username;
email.value=result.email;

}