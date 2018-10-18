<?php
header("Content-Type: text/xml;");
$category = (isset($_GET["category"]))?$_GET["category"]:"";
$themes = (isset($_GET["themes"]))?$_GET["themes"]:"";
$izd = (isset($_GET["izd"]))?$_GET["izd"]:"";
$page = (isset($_GET["page"]))?$_GET["page"]:0; //Номер страницы, который нужно отобразить
$itemsPerPage = 5; // кол-во книг на странице


$where = "";
if($category != "" && $category !="Все")
    $where .='WHERE category = "'.$category.'"';
if($themes != "" && $themes !="Все")
{
    if($where!="")
        $where .=" AND ";
    else
        $where .="WHERE ";
    $where .='themes = "'.$themes.'"';
}
if($izd != "" && $izd !="Все")
{
    if($where!="")
        $where .=" AND ";
        else
        $where .="WHERE ";
    $where .='izd = "'.$izd.'"';
}
//echo ($where);
$Link = new mysqli("localhost","root","","Library");
if($Link->connect_error)
{
    echo "Connect Error (".$Link->connect_errno.") ". $Link->mysqli_connect_error;
    exit();
}
$Link->query("SET NAMES UTF8");     
$res = $Link->query("SELECT COUNT(*) AS cnt FROM books $where");
if($res === false)
    die ("Ошибка запроса (".$link->errno.") : ".$link->error);
//print_r ( $where);
$row = $res->fetch_assoc();
$allItems = $row['cnt'];
$res->free();
$allPages = ceil($allItems / $itemsPerPage);

if($allPages>1)
$page = ($page > $allPages - 1)?($allPages-1):$page;
$bd = $Link->query("SELECT * FROM books $where ORDER BY name LIMIT ".($page * $itemsPerPage).", $itemsPerPage");
?>

<response>
<result>0</result>
    <data>
        <allPages><?=$allPages?></allPages>
        <page><?=$page?></page>
        <?php  for($i =0; $i<$bd->num_rows; $i++)
        { 
            $row = $bd->fetch_assoc(); // возврашает строку в таблице 
           
              ?>
        <book>
            <id><?=(isset($row['id']))?htmlspecialchars($row['id']):"-"?></id>
            <code><?=(isset($row['code']))?htmlspecialchars($row['code']):"-"?></code>
            <name><?=(isset($row['name']))?htmlspecialchars($row['name']):"-"?></name>
            <izd><?=(isset($row['izd']))?htmlspecialchars($row['izd']):"-"?></izd>
            <npages><?=(isset($row['npages']))?htmlspecialchars($row['npages']):"-"?></npages>
            <themes><?=(isset($row['themes']))?htmlspecialchars($row['themes']):"-"?></themes>
            <category><?=(isset($row['category']))?htmlspecialchars($row['category']):"-"?></category>
        </book>
        <?php } ?>
    </data>
    <method>getBooks</method>
</response>