async function loginUser() {
    event.preventDefault;
    const email = document.getElementById("Email").value;
    const password = document.getElementById("Password").value;
    const user = {
      Email: email,
      Password: password,
    };

    const response = await fetch("https://localhost:44358/api/Users/login", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(user),
      //converts the user object into a JSON string and sends it as the request body.
    });

    // const data = await response.text();
    window.location.href='../home/home.html';
  }