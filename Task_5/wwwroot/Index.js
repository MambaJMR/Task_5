let page = 1;
let count = 1;
let getValue = "en";
const sel = document.getElementById("sel");


async function getUsers(region, seed) {
     response = await fetch('https://localhost:44360/Index',
    {
        method: "POST",
        body: JSON.stringify(
        {
            region: region,
            seed: seed
        }),
        headers: { "Content-Type": "application/json" }
    })
    if (response.ok === true) {
        const users = await response.json();
        const rows = document.querySelector("tbody");
        users.forEach(user => rows.append(row(user)));
    }
}

function row(user) {


    const tr = document.createElement("tr");
    const numberTd = document.createElement("td");
    numberTd.append(count);
    tr.append(numberTd);
    count++;
    const idTd = document.createElement("td");
    idTd.append();
    tr.append(idTd);

    const nameTd = document.createElement("td");
    nameTd.append(user.fullName);
    tr.append(nameTd);

    const addressTd = document.createElement("td");
    addressTd.append(user.address);
    tr.append(addressTd);

    const phoneTd = document.createElement("td");
    phoneTd.append(user.phone);
    tr.append(phoneTd);
    return tr;
}

function updateTextInput(val) {
    let valMax = document.getElementById("customRange").max;
    let values = document.getElementById('textInput').value;
    if (values > valMax)
    {
        val = values;
    }
    else
    {
        document.getElementById('textInput').value = val; 
        console.log(values);
    }
    
  }

  window.addEventListener("scroll", () => 
  {
    const documentRect = document.documentElement.getBoundingClientRect();
    if (documentRect.bottom < document.documentElement.clientHeight + 150)
    {
        page++;
        getUsers(getValue, 1 + page);
    }

  })
  sel.addEventListener("change", () => 
  {
      getValue = sel.value;
      console.log("В методе "+ getValue);
  })
getUsers(getValue, 1);
