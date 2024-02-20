let page = 1;
let count = 1;
document.getElementById('textInput').max = 1000;
const form = document.querySelector('form');

document.getElementById('range').addEventListener('input', function() {
    var value = this.value;
    document.getElementById('textInput').value = value;
});

document.getElementById('textInput').addEventListener('input', function() {
    var value = this.value;
    if (value > 10) {
        value = 10;
    }
    document.getElementById('range').value = value;
});

document.getElementById('textInput').addEventListener('input', function() {
    var value = this.value;
    if (value > 1000) {
        document.getElementById('textInput').value = 1000;
    }
    if (value < 0) {
        document.getElementById('textInput').value = 0;
    }
    
});

document.getElementById('seedButton').addEventListener('click', function() {
    var randomNumber = Math.floor(Math.random()  *  10000);
    document.getElementById('seed').value = randomNumber; 

    data = {
        region: form.querySelector("[name='region']").value,
        seed: form.querySelector("[name='seed']").value,
        errorValue: form.querySelector("[name='errorValue']").value
    };
    $.ajax({
        url: '/Index',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(data),
        success: function(response) {
            createTable(response)
        }
    });
});
window.addEventListener("scroll", () => 
{
    const documentRect = document.documentElement.getBoundingClientRect();
    if (documentRect.bottom < document.documentElement.clientHeight + 150)
    {
        data = {
                region: form.querySelector("[name='region']").value,
                seed: form.querySelector("[name='seed']").value + page,
                errorValue: form.querySelector("[name='errorValue']").value
            };
            $.ajax({
                url: '/Index',
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(data),
                success: function(response) {
                    appendTableData(response)
                }
            });
    }
    page++;           
});

  $('form').on('change', function(e) {
    e.preventDefault();
    var data = {};
    $(this).find('input, select').each(function() {
        data[this.name] = this.value;
    });
    $.ajax({
        url: '/Index',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(data),
        success: function(response) {
            createTable(response)
        }
    });
});
  function createTable(data) {
    var table = document.createElement('table');
    table.className ='table container';
    table.id = 'myTable';
    var thead, tbody;
    count = 1;
    document.body.removeChild(document.body.lastChild); // удаляем старую таблицу

    thead = document.createElement('thead');
    tr = document.createElement('tr');
    td = document.createElement('th');
    td.textContent = "#";
    tr.appendChild(td);

    td = document.createElement('th');
    td.textContent = "ID";
    tr.appendChild(td);

    td = document.createElement('th');
    td.textContent = 'Full Name';
    tr.appendChild(td);

    td = document.createElement('th');
    td.textContent = 'Address';
    tr.appendChild(td);

    td = document.createElement('th');
    td.textContent = 'Phone';
    tr.appendChild(td);

    thead.appendChild(tr);
    table.appendChild(thead);

    tbody = document.createElement('tbody');
    for(var i = 0; i < data.length; i++) {
        tr = document.createElement('tr');

        td = document.createElement('td');
        td.textContent = count;
        count++;
        tr.appendChild(td);

        td = document.createElement('td');
        td.textContent = data[i].id;
        tr.appendChild(td);

        td = document.createElement('td');
        td.textContent = data[i].fullName;
        tr.appendChild(td);

        td = document.createElement('td');
        td.textContent = data[i].address;
        tr.appendChild(td);

        td = document.createElement('td');
        td.textContent = data[i].phone;
        tr.appendChild(td);

        tbody.appendChild(tr);
    }

    table.appendChild(tbody);
    document.body.appendChild(table);
}

function appendTableData(data) {
    var table = document.getElementById('myTable');
    var tbody = table.getElementsByTagName('tbody')[0];
    var tr, td;

    for(var i = 0; i < data.length; i++) {
        tr = document.createElement('tr');
        td = document.createElement('td');
        td.textContent = count;
        count++;
        tr.appendChild(td);

        td = document.createElement('td');
        td.textContent = data[i].id;
        tr.appendChild(td);

        td = document.createElement('td');
        td.textContent = data[i].fullName;
        tr.appendChild(td);

        td = document.createElement('td');
        td.textContent = data[i].address;
        tr.appendChild(td);

        td = document.createElement('td');
        td.textContent = data[i].phone;
        tr.appendChild(td);

        tbody.appendChild(tr);
    }
}
