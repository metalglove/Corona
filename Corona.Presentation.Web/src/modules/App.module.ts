import { Module, MutationTree, ActionTree } from 'vuex';

export interface IAppState {

}

export interface IAppMutations extends MutationTree<IAppState> {

}

export interface IAppModule {
    namespaced?: boolean;
    state?: IAppState;
    mutations?: IAppMutations;
}

/**
 * Represents the app module class, an implementation of the IAppModule interface.
 */
export default class AppModule implements IAppModule, Module<IAppState, IAppState> {
    public namespaced?: boolean;
    public state?: IAppState;
    public mutations?: IAppMutations;

    /**
     * Initializes an instance of the AppModule.
     */
    public constructor() {
        this.namespaced = true;
        this.state = this.getAppState();
        this.mutations = this.getMutations();
    }

    private getAppState(): IAppState {
        const state: IAppState = {};
        return state;
    }

    private getMutations(): IAppMutations {
        const mutations: IAppMutations = {};
        return mutations;
    }
}
