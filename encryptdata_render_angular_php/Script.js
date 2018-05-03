//configuring the routes
var app = angular.module("demo", ["ngRoute","chart.js"])
                .config(function ($routeProvider) {
                    $routeProvider
                        .when("/home", {
                            templateUrl: "Home.html",
                            controller: "homecontroller"
                        })
                    
					
					.when("/node2",{
						templateUrl: "node2.html",
                        controller: "node2controller"
                    })
					
					.when("/node3",{
						templateUrl: "node3.html",
                        controller: "node3controller"
                    })
					
					.when("/ntc",{
						templateUrl: "ntc.html",
                        controller: "ntccontroller"
                    })
					
					.when("/ldr",{
						templateUrl: "ldr.html",
                        controller: "ldrcontroller"
                    })
					
					
                  })
				
              .controller("homecontroller", function ($scope,$http) {
                  $scope.message = "Home Page set dynamically";
				   
				   $http.get('data.php')
				 .then(function(response){
				 $scope.data22=response.data;})
				 

              })

             
			 
			
			.controller("node2controller", function ($scope,$http) {
                 $scope.message="Welcome to Tempsensor log of node2";
                
	             $http.get('selectfortemp.php?src=2')
				 .then(function(response){
				 $scope.data=response.data;})
				 
				 
			 
			})
			
			.controller("node3controller", function ($scope,$http) {
                 $scope.message="Welcome to Tempsensor log of node3";
                
	             $http.get('selectfortemp.php?src=3')
				 .then(function(response){
				 $scope.data=response.data;})
				 
				 
			 
			})
			
			
			.controller("ntccontroller", function ($scope,$http) {
                 $scope.message="Time vs NTC";
                
	             $http.get('selectforgraphtime.php')
				 .then(function(response){
				 $scope.label=response.data;})
				  
				  $http.get('selectforgraphntc.php')
				 .then(function(response){
				 $scope.data=response.data;})
				 
				 $scope.series = ['Series A', 'Series B'];
			 
			})
			
			.controller("ldrcontroller", function ($scope,$http) {
                 $scope.message="Time vs LDR";
                
	             $http.get('selectforgraphtime.php')
				 .then(function(response){
				 $scope.label=response.data;})
				  
				  $http.get('selectforgraphldr.php')
				 .then(function(response){
				 $scope.data=response.data;})
				 
				 $scope.series = ['Series A', 'Series B'];
			 
			})
			
			
