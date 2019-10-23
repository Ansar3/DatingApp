import { Photo } from './Photo';
// tslint:disable-next-line: class-name
export  interface User {
    id: number;
    username: string;
    knownAs: string;
    age: number;
    gender: string;
    created: Date;
    lastActive: Date;
    photoUrl: string;
    city: string;
    country: string;
    intrests?: string;
    introduction: string;
    lookingFor?: string;
    photos?: Photo[];

    }
