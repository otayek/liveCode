package com.example.TesteJava.controller;

import com.example.TesteJava.application.ListaCartaoApplication;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Component;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;

import java.util.List;


@Component
public class ListaCartaoController {

    public ListaCartaoApplication listaCartao;

    public ListaCartaoController(ListaCartaoApplication listaCartao) {
        this.listaCartao = listaCartao;
    }

    @GetMapping("/consulta/cartao")
    public ResponseEntity<Object> ConsultaListaCartao (@RequestParam("cpf") String cpf){
        try{
            List<Object> data = listaCartao.ListaCartao(cpf);
            return ResponseEntity.ok(data);
        }catch (Exception ex)
        {
            return new ResponseEntity<Object>(ex.getMessage(), null, HttpStatus.BAD_REQUEST);
        }
    }
}
