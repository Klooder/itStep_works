<?php
    $file = (isset($_FILES["file"]))?$_FILES["file"]:"";
    if($file["size"] == 0 || $file == "")
    {
        header("Location: HW_im.php?err=Выберите файл!&com=1");
        exit();
    }

    if($file["error"] !=0 )
    {
        header("Location: HW_im.php?err=Ошибка загрузки файла: {$F['error']}&com=1");
        exit();
    }

    $arrTypes = ["image/png", "image/gif", "image/jpeg"];
    if(!in_array($file["type"], $arrTypes))
    {
        header("Location: HW_im.php?err=Недопустимый формат MIME тип файла: {$F['type']}&com=1");
        exit();
    }

    $arrExt = [".png", ".jpg", ".gif"];
    $pos = strrpos($file["name"], ".");
    if($pos === false)
    {
        header("Location: HW_im.php?err=Недопустимое расширение файла&com=1");
        exit();
    }

    $ext = substr($file["name"], $pos);
    if(!in_array($ext, $arrExt))
    {
        header("Location: HW_im.php?err=Недопустимое расширение файла: $ext&com=1");
        exit();
    }
   
    if(!move_uploaded_file($file["tmp_name"], "./bigimages/".$file["name"]))
    {
        header("Location: HW_im.php?err=Ошибка переноса файла&com=1");
        exit();
    }
    $filename = "./bigimages/".$file["name"];
    // получение новых размеров
list($width, $height) = getimagesize($filename);

if($width > $height)
{
    $new_width = 342;
    $new_height = 245;
}
else{
    $new_width = 200;
    $new_height = 245;   
}



$image_p = imagecreatetruecolor($new_width, $new_height);
$image = imagecreatefromjpeg($filename);
imagecopyresampled($image_p, $image, 0, 0, 0, 0, $new_width, $new_height, $width, $height);

// вывод
imagejpeg($image_p, "./smallimages/".$file["name"], 100);
imagedestroy($image);
  
    $img = imagecreatefromjpeg($filename); 
    $white = imagecolorallocatealpha ($img, 104, 133, 122, 25);
    $font = "C:/OSPanel/domains/HW/font.ttf";
    $text = '(c) Коала';
    imagettftext($img,18 ,0 , 20,30, $white,$font,$text);
    imagejpeg($img, "./bigimages/".$file["name"], 100);
    imagedestroy($img);



header("Location: HW_im.php?sm=./smallimages/{$file["name"]}&bg=./bigimages/{$file["name"]}&com=1");
exit();
?>
