import { Lote } from './Lote';
import { Palestrante } from './Palestrante';
import { RedeSocial } from './RedeSocial';

export interface Evento {
    id: number;
    tema: string;
    local: string;
    lotes: Lote[];
    qtdPessoas: number;
    date: Date;
    imageUrl: string;
    telefone: string;
    email: string;
    redesSociais: RedeSocial[];
    palestrantesEventos: Palestrante[];
}
