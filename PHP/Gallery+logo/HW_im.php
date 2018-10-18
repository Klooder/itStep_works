<?php
   
    $err = (isset($_GET["err"]))?$_GET["err"]:"";
    $bg = (isset($_GET["bg"]))?$_GET["bg"]:"";
    $sm = (isset($_GET["sm"]))?$_GET["sm"]:"";

?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>HW</title>
    <link href="./bootstrap/css/bootstrap.min.css" rel="stylesheet">
</head>
<body id="con" >
    <div id="d">
<form action="HW_im2.php" method="POST" enctype="multipart/form-data" style=" position: center;">
    <!-- <input type="submit" value="Отправить"/> --> 

<div class="input-group" style="margin: 20px; width: 30%;">
  <div class="custom-file">
    <input type="file" name="file" class="custom-file-input" id="inputGroupFile04" aria-describedby="inputGroupFileAddon04">
    <label class="custom-file-label" for="inputGroupFile04">Выберите файл...</label>
  </div>
  <div class="input-group-append">
    <button class="btn btn-outline-secondary" type="submit" id="inputGroupFileAddon04">Загрузить</button>
  </div>
</div> 
<?php
if ($err !="")
{
    ?>
    <span   style="color: red;  position: absolute; left: 32%; top: 3%"><?=$err?></span>
    <?php

}
?>
</form>
<div id="div" style="margin: 20px; ">
<?php
// if($sm)
// {
    ?>
<script>
var div = document.getElementById("div");
var div2 = document.getElementById("d");

    <?php   
        $dir = "./smallimages/";
        $dirB = "./bigimages/";
        if (is_dir($dir)) {
        if ($dh = opendir($dir)) {
        while (($file = readdir($dh)) !== false) {
            if($file=="." || $file =="..") continue;
    ?>
         var div_im = document.createElement("div");
         div_im.style.cssFloat = "left";
        var im = document.createElement("img");
        im.className = "img-thumbnail";
        div_im.style.textAlign = "center";
        div_im.style.margin = "15px";
        im.style.position = "relative";
        im.src = "<?= $dir.$file ?>";
        div_im.style.height = "245px";
        div_im.style.width = "342px";
        
        im.onclick = function(e)
        {
            document.getElementById("d").style = "pointer-events: none; opacity: 0.5;background: black;";
            var d_n = document.createElement("div");
            d_n.style.height = window.innerHeight * 0.5;
            d_n.style.width = "80%";
            d_n.style.left = "10%";
            d_n.style.top = "0%";
            d_n.style.display = "block";
            d_n.style.position = "fixed";
            d_n.style.textAlign = "center";
            d_n.id = "d_n";
            
            var i = document.createElement("img");
            i.className = "img-thumbnail";
            i.src = "<?= $dirB.$file ?>";

            var but = document.createElement("button");
            but.id="but1";
            but.className = 'btn btn-dark';
            but.style=' position: fixed; top: 0.5%; left:98%; background: black; border: 0px; opacity: 0.5;disabled=true';
            but.textContent = "X";
            but.onclick= function (e)
            {
                var div = document.getElementById("con");
                d_n.remove();
                but.remove();
                document.getElementById("d").style = "pointer-events: auto; opacity: 1";
            }
            d_n.appendChild(i); 
            document.getElementById("con").appendChild(d_n); 
            document.getElementById("con").appendChild(but);
        };
        div_im.appendChild(im);
        div.appendChild(div_im);
        
<?php 
       }
        closedir($dh);
    }
}
?>
    </script>
</div> 
</div> 
</body>
</html>