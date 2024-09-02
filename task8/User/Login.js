
// debugger;
// form.addEventListener("submit",async function loginUser() {
//     event.preventDefault;
//     const url ="https://localhost:44358/api/Users/login";

//     var form=document.getElementById("form");

// var formData= new FormData(form);
// let response=await fetch(url,{
// method:"POST",
// body:formData,
// })});


debugger;

async function signin() {
    event.preventDefault();
    debugger;
    var signin = document.getElementById("form");

    const formData = new FormData(signin);
    try {
        var requist = await fetch("https://localhost:44358/api/Users/login", {
            method: "POST",
            body: formData
        })
        if (requist.ok) {
            var data = await requist.text;
            localStorage.setItem("token", data.token);
            location.href = "../home/home.html";
        } else {
            alert("Invalid credentials");
        }
    }
    catch {
        alert("Network error");
    }


}