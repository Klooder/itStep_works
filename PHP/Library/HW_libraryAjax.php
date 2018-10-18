<?php
function Sorted($name){
    $category = (isset($_GET['category']))?$_GET['category']:"";
    $themes = (isset($_GET['themes']))?$_GET['themes']:"";
    $izd = (isset($_GET['izd']))?$_GET['izd']:"";
    $Link = new mysqli("localhost","root","","Library");
    if($Link->connect_error)
    {
    echo "Connect Error (".$Link->connect_errno.") ". $Link->mysqli_connect_error;
    exit();
    } 
    $rows = $Link->query("SELECT $name FROM books GROUP BY $name");
    if($rows)
    {
        echo "<option>Все</option>";
        for($i =0; $i<$rows->num_rows; $i++)
        {
            $row = $rows->fetch_assoc();
            if($row[$name]=="")continue;
            
            echo "<option ";
            if($row[$name]==$category || $row[$name]==$themes || $row[$name]==$izd){
            echo " selected ";
            }
            echo ">{$row[$name]}</option>";
        }
    }
    $rows->close();
    $Link->close();
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Library</title>
    <link href="./bootstrap/css/bootstrap.min.css" rel="stylesheet">
</head>
<body >
    
    <div class="card"  style="width:30%; height: auto; position: absolute; left: 34%; text-align: center; margin:1%; background-color: #f0f0f0 ">
        <h1 class="card-title">Библиотека</h1>
        <div style="margin: 5%; margin-top:2%; text-align: left">
        <div class="form-group">
            <label for="Select1">Категория</label>
            <select onchange="onchange1(0)" class="form-control" id="category" id="Select1"><?php Sorted('category');?></select>
        </div>
        <div class="form-group">
            <label for="Select2">Тематика</label>
            <select onchange="onchange1(0)" class="form-control" id="themes" id="Select2"><?php Sorted('themes');?>  </select>
        </div>
        <div class="form-group">
            <label for="Select3">Издательство</label>
            <select onchange="onchange1(0)" class="form-control" id="izd" id="Select3"><?php Sorted('izd');?>  </select>
        </div>
    </div>
    <div id="content" style="position: absolute; left: -55%; top: 110%; text-align: center; width: 1150px"></div>
  <div id="peginator" style='position: absolute; text-align: center'></div>


<script type="text/javascript">

    var req = null;
    function onchange1($page)
    {
       var category = document.getElementById("category").value;
       var themes = document.getElementById("themes").value;
       var izd = document.getElementById("izd").value;
      // alert(category);
         loadXmlGet('HW_libraryAjaxServ.php?category=' + encodeURIComponent(category) + '&themes=' +encodeURIComponent(themes)+'&izd='+encodeURIComponent(izd)+'&page='+$page); // отправка запроса AJAX c GET данными
    }
    function loadXmlGet(url)
    {
        if(req != null) return;
        url +="&r=" + Math.random();

        req = new XMLHttpRequest();
        req.onreadystatechange= processReqChange;
        req.open("GET", url, true);
        req.send(null);

    }
    function processReqChange() // обработчик события смены состояния XmlHttpRequest - получение ответа
        {
            if (req.readyState == 4) {
                req.onreadystatechange = null;
                if (req.status == 200) {
                    // alert(req.responseText); // отладочный 
                     var response = null;
                    if (window.XMLHttpRequest)
                        response = req.responseXML;                  // Если не IE
                    else response = req.responseXML.documentElement; // Если старый IE
                    var result = 0;
                    try {
                        result = response.getElementsByTagName('result').item(0).firstChild.data;
                    }
                    catch (e) {
                        result = -1;
                        alert("Ошибка извлечения result: " + e.message);
                    }
                    if (result == 0) {
                        try {
                            var method = response.getElementsByTagName('method').item(0).firstChild.data;
                            var data = response.getElementsByTagName('data').item(0);
                            eval(method + "(data)"); // Вызов метода обратного вызова
                        }
                        catch (e) {
                            alert("Ошибка извлечения method / data : " + e.message);
                        }
                    }
                    else {
                        alert("Произошла ошибка: " + result + "\n" + req.responseText);
                    }
                }
                else {
                    alert("There was a problem retrieving the XML data:\n" +
                        req.statusText + "\nError: " + req.status);
                }
                req = null;
            }
        }
    function getBooks(response)
    {
       
        var div = document.getElementById('content');
            div.innerHTML = "";
         
            var table = document.createElement("table");

 // --------------------------- Paginator -----
             var allPages = response.getElementsByTagName('allPages').item(0).firstChild.data;
           if(allPages>1)
           {
            var page = response.getElementsByTagName('page').item(0).firstChild.data;
          

                for(var i=0;i<allPages;i++)
                {
                var a = document.createElement("span");
                a.id=i+"j";
                a.style.textDecoration = "Underline";
                a.style.cursor = "pointer";
                a.appendChild(document.createTextNode(i+1));
                if(i ==page)
                {
                    a.style.color = "blue";
                    a.style.textDecoration = "none";
                }
                div.appendChild(a); 
                div.innerHTML += "&nbsp;&nbsp;";
                }
            }

            div.innerHTML += "&nbsp;&nbsp;";
            var arrBooks = response.getElementsByTagName('book');
           if(arrBooks.length>0)
           {
            var arrName = ["№", "Код", "Название", "Издательство", "Кол-во страниц","Категория", "Тема"];
            var tr = table.insertRow();
             tr.style.background = "#f0f0f0";
            for(var j=0;j<arrName.length;j++)
            {
                var th = tr.insertCell();
                th.appendChild(document.createTextNode(arrName[j]));
                th.setAttribute("scope","col");
               
            }
           
            for (var i = 0; i < arrBooks.length; i++) {
                var book = arrBooks.item(i);
                //------- Извлечение значения элементов книги ---------
                var id = book.getElementsByTagName("id").item(0).firstChild.data;
                var code = book.getElementsByTagName("code").item(0).firstChild.data;
                var name = book.getElementsByTagName("name").item(0).firstChild.data;
                 var izd = book.getElementsByTagName("izd").item(0).firstChild.data;
                var npages = book.getElementsByTagName("npages").item(0).firstChild.data;
                var category = book.getElementsByTagName("category").item(0).firstChild.data;
                var themes = book.getElementsByTagName("themes").item(0).firstChild.data;

                //-------- Создание строки таблицы и заполнение ее данными ---
                var row = table.insertRow(i+1);
                row.insertCell(0).appendChild(document.createTextNode(id));
                row.insertCell(1).appendChild(document.createTextNode(code));
                row.insertCell(2).appendChild(document.createTextNode(name));
                row.insertCell(3).appendChild(document.createTextNode(izd));
                row.insertCell(4).appendChild(document.createTextNode(npages));
                row.insertCell(5).appendChild(document.createTextNode(category));
                row.insertCell(6).appendChild(document.createTextNode(themes));
            }

            table.setAttribute("class", "table table-bordered table-hover");
            div.appendChild(table);
           }
           else{

            div.appendChild(document.createTextNode("По данному запросу ничего не найдено!"));
           }

           // --------------------------- Paginator -----
           if(allPages>1)
           {
          

           for(var i=0;i<allPages;i++)
           {
                var b = document.createElement("span");
                b.id=i+"i";
                b.style.textDecoration = "Underline";
                b.style.cursor = "pointer";
                b.appendChild(document.createTextNode(i+1));
                if(i ==page)
                {
                    b.style.color = "blue";
                    b.style.textDecoration = "none";
                }
            div.appendChild(b); 
            div.innerHTML += "&nbsp;&nbsp;";
         
          }
           }
         if(allPages>1)
         {
        for(var j=1; j<=allPages;j++)
        {
            if(j-1 == page)
                continue;
            
            Register(j-1+"i");
            Register(j-1+"j");
        }
    }
    }
    function Register(evId)
    {
        var elem = document.getElementById(evId);
        
        elem.onclick = function (event) {
            var elem = document.getElementById(evId);
           // alert(evId);
            onchange1(parseInt(evId,10));
            //scroll(0,0);
        }
    }
    onchange1(0);
</script>
</body>
</html>