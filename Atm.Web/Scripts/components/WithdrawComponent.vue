<template>
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card">
                    <div class="card-header">Withdraw money</div>
                    <div class="card-body">
                        <div class="form-group">
                            <label for="accountNumber">Account number</label>
                            <input v-model="form['accountNumber']" type="text" class="form-control" :class="{ 'is-invalid': form.errors.has('accountNumber') }"
                                   id="accountNumber" aria-describedby="accountHelp" placeholder="Enter number">
                            <has-error :form="form" field="accountNumber"></has-error>
                            <small id="accountHelp" class="form-text text-muted">Bank account number, from which money will be withdraw.</small>
                        </div>
                        <div class="form-group">
                            <label for="amount">Account number</label>
                            <input v-model="form['amount']" type="text" class="form-control" :class="{ 'is-invalid': form.errors.has('amount') }"
                                   id="amount" aria-describedby="amountHelp" placeholder="Enter amount">
                            <has-error :form="form" field="amount"></has-error>
                            <small id="amountHelp" class="form-text text-muted">Amount of money to withdraw.</small>
                        </div>
                        <button @click="withdraw()" type="button" class="btn btn-primary">Withdraw</button>
                    </div>
                </div>
            </div>
            <div v-if="withdrawal.notes" class="col-md-8 withdrawal-result">
                <div class="card">
                    <div class="card-header">Your withdrawal</div>
                    <div class="card-body">
                        <ul class="list-group">
                            <li v-for="note in withdrawal.notes" class="list-group-item d-flex justify-content-between align-items-center">
                                Note bill ${{note.note}}
                                <span class="badge badge-primary badge-pill">{{note.amount}}</span>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {                
                serviceUrl: 'https://localhost:44306/api/withdraw/withdraw',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                },
                form: new Form({
                    accountNumber: '',
                    amount: '',
                }),
                withdrawal: [],
            }
        },
        methods: {
            withdraw() {
                axios.post(this.serviceUrl, this.form, this.headers)
                    .then(response => {
                        Vue.set(this.withdrawal, 'notes', response.data.notes);
                    })
                    .catch((e) => {
                        let errors = {
                            [e.response.data.ParamName]: [e.response.data.Message]
                        };
                        console.dir(errors);
                        this.form.errors.set(errors);
                    });
            }
        }
    }
</script>
 