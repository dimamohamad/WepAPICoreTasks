const url="https://localhost:44358/api/Users/register";

var form=document.getElementById("form");
async function adduser(){
event.preventDefault();
var formData= new FormData(form);
let response=await fetch(url,{
method:"POST",
body:formData,
});
var data=response;

alert("the user added successfully");
window.location.href="Login.html";
}
