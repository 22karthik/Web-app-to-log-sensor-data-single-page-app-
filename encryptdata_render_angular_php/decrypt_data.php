<?php

include "connect.php";

$query="select src,time,packetno,encrypted_data from encrypted_data";

$rs=$dbhandle->query($query);


 
while ($row = $rs->fetch_assoc()) {
	
  $time=$row['time'];
  $src=$row['src'];
  $packetno=$row['packetno'];
  $data = $row['encrypted_data'];
  
var_dump($src);
  
  writeMsg($time,$src,$packetno,$data,$dbhandle);
 
 }
 
 function writeMsg($time,$src,$packetno,$data,$dbhandle)
 {
	 var_dump(openssl_get_cipher_methods());
	
	$key = hex2bin('2b7e151628aed2a6abf7158809cf4f3c');
    $iv = hex2bin('f0f1f2f3f4f5f6f7f8f9fafbfcfdfeff');
	
	
	$input1=trim($data);
	
	 $input=hex2bin($input1);
    
	
	$output = openssl_decrypt($input, 'AES-128-CTR', $key,OPENSSL_RAW_DATA, $iv);
	 
	
	$newstr = filter_var($output, FILTER_SANITIZE_STRING);
	 
	
	
	$decrypt=explode(' ',$newstr);
	
	$LDR=(int)$decrypt[1];
	$NTC=(double)$decrypt[2];
	
	if(strcmp($decrypt[0],'fgh')){
 
     echo "authentication sucessfully done";
	 
    $query1="insert into node2(time1,src,packetno,NTC1,LDR1)values('$time','$src','$packetno','$NTC','$LDR')";
		
		if($dbhandle->query($query1))
		{
			
			echo "successfully inserted";
		}
		else
		{
			echo "check the insert could not  insert";
		}
	
	}
	
	 else
		echo "authentication failed";
 }
?>
