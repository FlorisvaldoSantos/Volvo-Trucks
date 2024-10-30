import { useParams, useNavigate } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css"
import "bootstrap/dist/js/bootstrap.bundle.min";

import React, { useState, useEffect } from "react";
import { URL_CREATE, URL_UPDATE, URL_GET_ID } from "../utils/config";


const Truck = () => {

  const { id } = useParams();

  const navigate = useNavigate();

  const backToHome = () => {
    navigate('/');
  };

  const InicialParameters = {
    id: null,
    model: null,
    fabricateyear: 0,
    chassi_Code: "",
    color: "",
    plan: null
  };

  const [truckLoad, setTruck] = useState(InicialParameters);
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(true);

  const handleInputChange = event => {
    const { name, value } = event.target;
    setTruck({ ...truckLoad, [name]: value });
  };



  useEffect(() => {

    const fetchData = async () => {

      if (id == undefined || id == 0)
        return;

      try {
        const response = await fetch(URL_GET_ID + id);
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        const result = await response.json();
        console.log(result);

        setTruck(result);


      } catch (error) {
        setError(error.message);
      } finally {
        setLoading(false);
      }
    };

    fetchData();

  }, []);

  const CreateTruck = async () => {
    try {
      debugger
      var data = {
        fabricateyear: truckLoad.fabricateyear,
        chassi_Code: truckLoad.chassi_Code,
        color: truckLoad.color,
        plan: parseInt(truckLoad.plan),
        model: parseInt(truckLoad.model)
      }
      console.log(data);

      const response = await fetch(URL_CREATE, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
      });

      if (!response.ok) {
        throw new Error('Network response was not ok');
      }

      const result = await response.json();
      console.log('Success:', result);

      backToHome();

    } catch (error) {
      console.error('Error posting data:', error);
    }
  }

  const UpdateTruck = async () => {
    try {
      debugger
      var data = {
        id: id,
        fabricateyear: truckLoad.fabricateyear,
        chassi_Code: truckLoad.chassi_Code,
        color: truckLoad.color,
        plan: parseInt(truckLoad.plan),
        model: parseInt(truckLoad.model)
      }
      console.log(data);

      const response = await fetch(URL_UPDATE, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
      });

      if (!response.ok) {
        throw new Error('Network response was not ok');
      }

      const result = await response.json();
      console.log('Success:', result);

      backToHome();

    } catch (error) {
      console.error('Error posting data:', error);
    }
  }

  const TryValidate = () => {
    debugger;
    if (truckLoad.chassi_Code === '' || truckLoad.chassi_Code === undefined) {
      alert("Field is required: Chassi Code");
      return false;
    }

    if (truckLoad.fabricateyear === 0 || truckLoad.fabricateyear === undefined) {
      alert("Field is required: Fabricate Year");
      return false;
    }

    if (truckLoad.color === '' || truckLoad.color === undefined) {
      alert("Field is required: Color");
      return false;
    }

    if (isNaN(truckLoad.plan) || truckLoad.plan == null || truckLoad.plan === '') {
      alert("Field is required: Plan");
      return false;
    }

    if (isNaN(truckLoad.model) || truckLoad.model == null || truckLoad.model === '') {
      alert("Field is required: Model");
      return false;
    }

    return true;
  }

  const saveTruck = async (e) => {
    e.preventDefault();

    if (!TryValidate())
      return;

    debugger
    console.log("id:" + id);
    if (id == undefined)
      CreateTruck();

    if (id > 0)
      UpdateTruck();
  };


  return (

    <div class="row ">
      <div class="col-lg-10 mx-auto">
        <div class="card mt-4 mx-auto p-6 bg-light">
          <div class="card-body bg-light">
            <div class="container">


              <form name="formu" class="col-mt-8">
                <div class="form-group row">
                  <label for="chassi_Code" class="col-sm-2 col-form-label">Chassi Code</label>
                  <div class="col-sm-5">
                    <input type="text" class="form-control" id="chassi_Code" name="chassi_Code" placeholder="LVVDA11A75D029813" value={truckLoad.chassi_Code} onChange={handleInputChange} />
                  </div>

                  <label for="fabricateyear" class="col-sm-2 col-form-label">Fabricate Year</label>
                  <div class="col-sm-3">
                    <input type="number" class="form-control" id="fabricateyear" name="fabricateyear" placeholder="2024" value={truckLoad.fabricateyear} onChange={handleInputChange} />
                  </div>
                </div>
                <div class="form-group row">
                  <label for="color" class="col-sm-2 col-form-label">Color</label>
                  <div class="col-sm-10">
                    <input type="text" class="form-control" id="color" name="color" placeholder="Color" value={truckLoad.color} onChange={handleInputChange} />
                  </div>
                </div>
                <div class="form-group row">
                  <label for="color" class="col-sm-2 col-form-label">Plan</label>
                  <div class="col-sm-10">
                    <select id="plan" name="plan" class="form-control" required="required" data-error="Please specify your need." value={truckLoad.plan} onChange={handleInputChange}>
                      <option value="0" selected disabled>--Select Your Issue--</option>
                      <option value="1">Brasil</option>
                      <option value="2">Suécia</option>
                      <option value="3">Estados Unidos</option>
                      <option value="4">França</option>
                    </select>
                  </div>
                </div>
                <fieldset class="form-group row">
                  <div class="row">
                    <legend class="col-form-label col-sm-2">Model</legend>
                    <div class="col-sm-3">
                      <div class="form-check">
                        <input class="form-check-input" type="radio" name="model" id="model" value="1" checked={truckLoad.model == 1} onChange={handleInputChange} />
                        <label class="form-check-label" for="model"> FH </label>
                      </div>
                      <div class="form-check">
                        <input class="form-check-input" type="radio" name="model" id="model2" value="2" checked={truckLoad.model == 2} onChange={handleInputChange} />
                        <label class="form-check-label" for="model2"> FM  </label>
                      </div>
                      <div class="form-check">
                        <input class="form-check-input" type="radio" name="model" id="model3" value="3" checked={truckLoad.model == 3} onChange={handleInputChange} />
                        <label class="form-check-label" for="model3"> VM </label>
                      </div>
                    </div>
                  </div>
                </fieldset>
                <div class="form-group row ">
                  <div class="d-flex justify-content-end">
                    <div class="col-sm-3">
                      <button class="btn btn-danger w-100" onClick={backToHome}><strong>Back</strong></button>
                    </div>&nbsp;&nbsp;
                    <div class="col-sm-3">
                      <button class="btn btn-success w-100" onClick={saveTruck} ><strong>Save</strong></button>
                    </div>
                  </div>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>

  );
};

export default Truck;
