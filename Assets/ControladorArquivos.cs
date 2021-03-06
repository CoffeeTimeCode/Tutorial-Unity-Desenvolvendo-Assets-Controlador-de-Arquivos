﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ControladorArquivos {
	private string _caminho;

	public ControladorArquivos(){
		this._caminho = Application.dataPath;
	}

	public bool validarDiretorio(string nome){
		return Directory.Exists (this._caminho+"/"+nome);
	}

	public bool validarArquivo(string nome){
		return File.Exists (this._caminho+"/"+nome);
	}

	public void criarDiretorio(string nome){
		if (this.validarDiretorio (nome)) {
			Debug.Log("Esse diretorio ja existe.");
		} else {
			Directory.CreateDirectory(this._caminho+"/"+nome);
		}
	}

	public void criarArquivo(string nome, string conteudo){
		if (this.validarArquivo (nome)) {
			Debug.Log("Esse arquivo ja existe");
		} else {
			var arquivo = File.CreateText(this._caminho+"/"+nome);
			arquivo.WriteLine(conteudo);
			arquivo.Close();
		}
	}

	public string lerArquivo(string nome){
		if (this.validarArquivo (nome)) {
			var arquivo = File.OpenText(this._caminho+"/"+nome);
			string temp = arquivo.ReadLine().ToString();
			arquivo.Close();
			return temp;
		} else {
			Debug.Log("Esse arquivo nao existe");
			return "";
		}
	}

	public T lerJson<T>(string nome){
		string json = this.lerArquivo (nome);
		if (json != "") {
			return JsonUtility.FromJson<T> (json);
		} else {
			return default(T);
		}
	}
}
