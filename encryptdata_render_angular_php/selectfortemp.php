<?php

include "connect.php";

if(isset($_GET['src']))
{
   $src=$_GET['src'];

}


$query="select time1,NTC1,LDR1 from node2 where src=$src";

$rs=$dbhandle->query($query);

while ($row = $rs->fetch_assoc()) {
  $data[] = $row;
}

	
	
    print json_encode($data);
?>
