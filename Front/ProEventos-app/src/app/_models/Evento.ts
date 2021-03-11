import { DateTimeFormatPipe } from '../helpers/DateTimeFormat.pipe';
import { Lotes } from './Lotes';
import { PalestranteEvento } from './PalestranteEvento';
import { RedeSocial } from './RedeSocial';

export interface Evento{
id: number;
local: string;
dataEvento?: Date;
tema: string;
qtdPessoas: number;
imagemURL: string;
telefone: string;
email: string;
lotes: Lotes[];
redesSociais: RedeSocial[];
palestrantesEventos: PalestranteEvento[];
}

