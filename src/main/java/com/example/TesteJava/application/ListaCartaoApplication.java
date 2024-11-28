package com.example.TesteJava.application;

import com.example.TesteJava.service.ListaCartaoService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.util.List;
import java.util.stream.Collectors;

@Component
public class ListaCartaoApplication {

    @Autowired
    private ListaCartaoService listaCartaoService;

    public ListaCartaoApplication (ListaCartaoService listaCartaoService) {
        this.listaCartaoService = listaCartaoService;
    }

    public List<Object> ListaCartao(String cpf) {

        List<Object> data = listaCartaoService.ListaCartao(cpf);

        return data.sort();
    }
}
