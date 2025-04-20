import { defineStore } from 'pinia';

export const useUserStore = defineStore('user', {
    state: () => ({
        name: '',
        email: '',
    }),
    actions: {
        setUser(name: string, email: string) {
            this.name = name;
            this.email = email;
        },
    },
});
