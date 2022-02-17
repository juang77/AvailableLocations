import React, { Component } from 'react';

export class UploadFile extends Component {
    static displayName = UploadFile.name;

    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };
    }

    render() {
        return (
            <div>
                <h1>Location APP - Fill Table!</h1>
                <p>Welcome to React functionality that allows you to upload a file and fill the Data in DataBase.</p>
            </div>
        );
    }
}
