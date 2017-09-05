/*
 * Almacena la tabla de componentes lexicos estaticos y dinamicos
 * */
using System;
using System.Collections;

namespace WindowsApplication1
{
	/// <summary>
	/// Descripción breve de CCompoLex.
	/// </summary>
	public class CCompoLex
	{
		#region Variables de la clase

		private string sNombreTabla;
		//Id = 1
		public string []sPalReservadas = { "abstract","as","base","bool","break","byte","case","catch","char","checked","class","const","continue","decimal","default","delegate","do","double","else","enum","evento","explicit"
										  ,"extern","endregion","false","finally","fixed","float","for","foreach","goto","if","implicit","in","int","interface","internal","is","lock","long","namespace","new","null","object"
										  ,"operator","out","override","params","private","protected","public","readonly","ref","return","region","sbyte","sealed","short","sizeof","stackalloc","static","string","struct","switch",
										   "this","throw","true","try","typeof","uint","ulong","unchecked","unsafe","ushort","using","virtual","volatile","void","while"};
		//Id = 2
		public string []sOpAritmeticos = {"/","*","+","-","**"};
		//Id = 3
		public string []sOpRelacionales = {">","<",">=","<=","==","!="};
		//Id = 4
		public string []sOpLogicos      = {"&&","||","!"};
		//Id = 5
		public string []sParCircular    = {"(",")"};
		//Id = 6
		public string []sParCuadrado    = {"[","]"};
		//Id = 7
		public string []sLlaves = {"{","}"};				
		//Id = 8
		public static ArrayList iIdentificador;
		//Id = 9
		public static ArrayList NumerosEnteros;
		//Id = 10
		public static ArrayList NumerosFlotantes;
		//Id = 11
		public static ArrayList NumerosNotacionCientifica;		

		public char [] iDigitos = {'0','1','2','3','4','5','6','7','8','9'};
		public char [] cAlfabeto = {'a','b','c','d','e','f','g','h','i','j','k','l','m','n',
									   'o','p','q','r','s','t','u','v','w','x','y','z','A','B','C'
									   ,'D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R',
									   'S','T','U','V','W','X','Y','Z'};
		public char [] cCarMin = {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','ñ','o',
									 'p','q','r','s','t','u','v','w','x','y','z'};
		public char [] cCarMay = {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','Ñ',
									 'O','P','Q','R','S','T','U','V','W','X','Y','Z'};

		public char [] cCarEspecialOpAritmeticos = {'*','/','+','-'};
		public char [] cCarEspecialOpRelacionales = {'>','<','=','!'};
		public char [] cCarEspecialOpLogicos = {'&','|','!'};
		public char cCarEspecialOpAsignacion = '=';
		public char [] cCarEspecialParCircular = {'(',')'};
		public char [] cCarEspecialParCuadrado = {'[',']'};
		public char [] cCarEspecialLlaves = {'{','}'};

		public char [] cCarEspecial = {'*','/','+','-','>','<','=','!','&','|','(',')','[',']','{'
									,'}',';','\n','\r','\t'};

		#endregion
				
		#region Metodos Gets o Sets

		public string nombreTabla
		{			
			get{return sNombreTabla; }
		}		


		#endregion

		#region Constructores

		public CCompoLex()
		{			
			//
			// TODO: agregar aquí la lógica del constructor
			//
			sNombreTabla = "Componente Lexicos";
		}


		#endregion
	}
}
