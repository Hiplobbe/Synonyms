/* eslint-disable no-restricted-globals */
/* eslint-disable react/style-prop-object */
import React, { Component } from 'react';

export class AddSynonym extends Component {
    static displayName = AddSynonym.name;

    constructor(props) {
        super(props);
        this.state = { word: "", synonym: "", success: false, failure: false };

        this.handleInputChange = this.handleInputChange.bind(this);
        this.addWord = this.addWord.bind(this);
    }

    handleInputChange(event) {
        const target = event.target;
        const value = target.value;
        const name = target.name;

        this.setState({
            [name]: value
        });
    }

    render() {
        return (
            <div>
                <h1>Add Synonym</h1>

                <p>Add your word with its connected synonym.</p>

                <p style={{color: "green", visibility: this.state.success ? 'visible' : 'hidden' }}> Word was added! </p>
                <p style={{color: "red", visibility: this.state.failure ? 'visible' : 'hidden' }}> Fields cannot be empty, and you cannot add words that already exist in the list. </p>

                <label>Word</label>
                <br />
                <input value={this.state.word} onChange={this.handleInputChange} name="word" type="text" />
                <br />
                <br />
                <label>Synonym (single or comma seperated)</label>
                <br />
                <input value={this.state.synonym} onChange={this.handleInputChange} name="synonym" type="text" />
                <br />
                <br />
                <button className="btn btn-primary" onClick={this.addWord}>Add word</button>
            </div>
        );        
    }

    addWord() {
        if (this.state.word, this.state.synonym) {
            const requestOptions = {
                method: 'post',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ word: this.state.word, synonym: this.state.synonym })
            };

            fetch('/home/add', requestOptions)
                .then(
                    (response) =>
                    {
                        if (response.ok) {
                            this.setState({ word: "", synonym: "", success: true });
                        }
                        else {
                            this.setState({ failure: true });
                        }
                    }
            );
            
        }
    }
}
