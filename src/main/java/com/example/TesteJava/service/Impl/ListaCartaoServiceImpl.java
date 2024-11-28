package com.example.TesteJava.service.Impl;

import com.example.TesteJava.service.ListaCartaoService;
import org.springframework.stereotype.Component;
import org.springframework.web.client.RestTemplate;

import java.util.Collections;
import java.util.List;

@Component
public class ListaCartaoServiceImpl  implements ListaCartaoService {

    public static final String PATH_API = "/api";


    @Override
    public List<Object> ListaCartao (String cpf) {
        RestTemplate restTemplate = new RestTemplate();
        return Collections.singletonList(restTemplate.getForObject("http://" + cpf + PATH_API, Object.class));
    }
}
